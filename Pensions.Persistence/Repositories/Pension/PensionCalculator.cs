using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Persistence.Interfaces.PensionCalculator;
using Pensions.Core.Services.Interfaces.Pension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensions.Persistence.Repositories.PensionCalculator
{
    public class PensionCalculator:IPensionCalculator
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAccrualRepository _accrualRepository;
        private readonly IPensionRepository _pensionRepository;
        public PensionCalculator(ISalaryRepository salaryRepository,
            IServiceRepository serviceRepository,
            IAccrualRepository accrualRepository,
            IPensionRepository pensionRepository)
        {
            _salaryRepository = salaryRepository;
            _serviceRepository = serviceRepository;
            _accrualRepository = accrualRepository;
            _pensionRepository = pensionRepository;

        }

        public async Task<double> GetPensionByIdAsync(int basicId,bool saveCalculations=false)
        {
            var service = await _serviceRepository.GetByMemberId(basicId);
            
            double totalNoofDays = 0;
            var lastService = service.Where(s => s.EndDate == null).FirstOrDefault();
            if(lastService==null)
            {
                lastService = service.OrderByDescending(s => s.EndDate).FirstOrDefault();
            }
            foreach(var s in service)
            {
                var endDate = (s.EndDate) == null ? DateTime.Now : s.EndDate.GetValueOrDefault();
                var startDate = s.StartDate;
                var NoofDays = Math.Round((endDate - startDate).TotalDays, 2);
                totalNoofDays = totalNoofDays + NoofDays;
            }

            var finalSalary = await _salaryRepository.GetLatestSalaryByMemberIdAsync(basicId);
            var lastServiceDate = lastService.EndDate == null ? DateTime.Now : lastService.EndDate;
            var accrual = await _accrualRepository.GetByMemberEndDateAsync(lastServiceDate.GetValueOrDefault());
            var pension = Math.Round(((totalNoofDays / 365) * (finalSalary / accrual)),2);

            if(saveCalculations)
            {
                await _pensionRepository.AddAsync(new Core.Models.Results() { BasicId = basicId,DateOfCalculation=DateTime.Now,Value=pension });
            }
            return pension;
        }
    }
}
