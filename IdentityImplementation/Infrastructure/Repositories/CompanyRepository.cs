using Core;
using Infrastructure.Context;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface ICompanyRepository : IRepository<Company, Guid, WorkerContext>
    {
        IEntity<Guid> AddCompany(string tradingCode);
    }

    public class CompanyRepository : Repository<Company, Guid, WorkerContext>, ICompanyRepository
    {
        public CompanyRepository(WorkerContext dbContext)
            : base(dbContext)
        {

        }

        public IEntity<Guid> AddCompany(string tradingCode)
        {
            try
            {
                var company = Get(x => x.TradingCode.Equals(tradingCode)).FirstOrDefault();
                
                //Checking weather the company does already exists. If not then insert
                if (company == null)
                    company = Add(new Company { TradingCode = tradingCode });

                return new Entity<Guid>(company, nameof(company.Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
