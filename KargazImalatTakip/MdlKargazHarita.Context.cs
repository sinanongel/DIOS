﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KargazImalatTakip
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KargazHaritaEntities : DbContext
    {
        public KargazHaritaEntities()
            : base("name=KargazHaritaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAGLANTI_ELEMANLARI_PE> BAGLANTI_ELEMANLARI_PE { get; set; }
        public virtual DbSet<SERVIS_ELEMANLARI> SERVIS_ELEMANLARI { get; set; }
        public virtual DbSet<SERVIS_KUTUSU> SERVIS_KUTUSU { get; set; }
        public virtual DbSet<VANA> VANA { get; set; }
        public virtual DbSet<BAGLANTI_ELEMANLARI_CELIK> BAGLANTI_ELEMANLARI_CELIK { get; set; }
        public virtual DbSet<ilce> ilce { get; set; }
        public virtual DbSet<HATLAR> HATLAR { get; set; }
        public virtual DbSet<SERVIS_HATLARI> SERVIS_HATLARI { get; set; }
    }
}
