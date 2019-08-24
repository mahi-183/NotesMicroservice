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
    /// Authentication user class derived from DbContext class provided by microsoft entityFramework core
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AuthenticationContext : DbContext
    {
        /// <summary>
        /// pass the instance of the DbContextOptions class to the base DbContext class<see cref="AuthenticationContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AuthenticationContext(DbContextOptions options) : base(options) 
        {

        }

        /// <summary>
        /// we will use this DbSet Notes to query and save the instances of the Notes model
        /// </summary>
        public DbSet<NotesModel> Notes { get; set; }

        /// <summary>
        /// we will use this DbSet Notes to query and save the instances of the Notes model
        /// </summary>
        public DbSet<LabelModel> Label { get; set; }

        /// <summary>
        /// we will use this DbSet Notes to query and save the instances of the Collaborator model 
        /// </summary>
        public DbSet<CollaboratorModel> Collaborator { get; set; }
    }
}
