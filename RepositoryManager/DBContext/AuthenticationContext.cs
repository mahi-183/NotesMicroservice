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
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<NotesModel> Notes { get; set; }
    }
}
