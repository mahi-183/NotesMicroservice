// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationContext.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryManager.DBContext
{
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    /// <summary>
    /// AuthenticationContext is for Authentication
    /// </summary>
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KOH93I0;Database=NotesDB;Trusted_connection=True;MultipleActiveResultSets=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
        public DbSet<NotesModel> Notes { get; set; }
    }
}
