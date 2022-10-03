using Microsoft.EntityFrameworkCore;
using AP1_P1_FrankYeuri.Models;


namespace AP1_P1_FrankYeuri.DAL
{ 

    public class Contexto : DbContext
        {
            public DbSet<Aportes>Aportes{get; set;}
        
            public Contexto(DbContextOptions<Contexto> options) : base(options)
            {   
            }
            
        } 


}