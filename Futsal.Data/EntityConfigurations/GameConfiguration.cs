using System;
using Futsal.Business.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Futsal.Data.EntityConfigurations
{
    public class GameConfiguration
    {
        public static void GetTypeBuilder(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
