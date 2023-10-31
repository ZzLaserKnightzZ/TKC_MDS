using Microsoft.EntityFrameworkCore;
using TKC_MDS.Models;

namespace TKC_MDS.Data
{
	public class SaleDev_Context:DbContext
	{
        public SaleDev_Context(DbContextOptions<SaleDev_Context> option):base(option) 
        {
            
        }
        public DbSet<Q_SchCustomer> q_SchCustomers { get; set; }  
        public DbSet<T_SchDataType_Cust> t_SchDataTypeCust { get; set; }
        public DbSet<T_SchDataType_MS> t_SchDataType_Ms { get; set; }
        public DbSet<T_SchFormConv> t_SchFormConv { get; set; }
        public DbSet<T_SchOrdersPart> t_SchOrdersParts { get; set; }

	}
}
