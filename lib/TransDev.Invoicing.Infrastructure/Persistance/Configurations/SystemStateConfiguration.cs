namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemStateConfiguration : IEntityTypeConfiguration<SystemState>
{
    public void Configure(EntityTypeBuilder<SystemState> builder)
    {
        builder
            .ToTable("SystemState");

        builder
            .HasKey(state => state.Id);

        builder
            .Property(state => state.Id)
            .IsRequired(true)
            .HasMaxLength(2);

        builder
            .Property(state => state.Name)
            .IsRequired()
            .HasMaxLength(45);

        #region [ Seed Data ]
        builder.HasData(
            new SystemState()
            {
                Id = "AL",
                Name = "Alabama"
            },
            new SystemState()
            {
                Name = "Alaska",
                Id = "AK"
            },
            new SystemState()
            {
                Name = "American Samoa",
                Id = "AS"
            },
            new SystemState()
            {
                Name = "Arizona",
                Id = "AZ"
            },
            new SystemState()
            {
                Name = "Arkansas",
                Id = "AR"
            },
            new SystemState()
            {
                Name = "California",
                Id = "CA"
            },
            new SystemState()
            {
                Name = "Colorado",
                Id = "CO"
            },
            new SystemState()
            {
                Name = "Connecticut",
                Id = "CT"
            },
            new SystemState()
            {
                Name = "Delaware",
                Id = "DE"
            },
            new SystemState()
            {
                Name = "District Of Columbia",
                Id = "DC"
            },
            new SystemState()
            {
                Name = "Federated States Of Micronesia",
                Id = "FM"
            },
            new SystemState()
            {
                Name = "Florida",
                Id = "FL"
            },
            new SystemState()
            {
                Name = "Georgia",
                Id = "GA"
            },
            new SystemState()
            {
                Name = "Guam",
                Id = "GU"
            },
            new SystemState()
            {
                Name = "Hawaii",
                Id = "HI"
            },
            new SystemState()
            {
                Name = "Idaho",
                Id = "ID"
            },
            new SystemState()
            {
                Name = "Illinois",
                Id = "IL"
            },
            new SystemState()
            {
                Name = "Indiana",
                Id = "IN"
            },
            new SystemState()
            {
                Name = "Iowa",
                Id = "IA"
            },
            new SystemState()
            {
                Name = "Kansas",
                Id = "KS"
            },
            new SystemState()
            {
                Name = "Kentucky",
                Id = "KY"
            },
            new SystemState()
            {
                Name = "Louisiana",
                Id = "LA"
            },
            new SystemState()
            {
                Name = "Maine",
                Id = "ME"
            },
            new SystemState()
            {
                Name = "Marshall Islands",
                Id = "MH"
            },
            new SystemState()
            {
                Name = "Maryland",
                Id = "MD"
            },
            new SystemState()
            {
                Name = "Massachusetts",
                Id = "MA"
            },
            new SystemState()
            {
                Name = "Michigan",
                Id = "MI"
            },
            new SystemState()
            {
                Name = "Minnesota",
                Id = "MN"
            },
            new SystemState()
            {
                Name = "Mississippi",
                Id = "MS"
            },
            new SystemState()
            {
                Name = "Missouri",
                Id = "MO"
            },
            new SystemState()
            {
                Name = "Montana",
                Id = "MT"
            },
            new SystemState()
            {
                Name = "Nebraska",
                Id = "NE"
            },
            new SystemState()
            {
                Name = "Nevada",
                Id = "NV"
            },
            new SystemState()
            {
                Name = "New Hampshire",
                Id = "NH"
            },
            new SystemState()
            {
                Name = "New Jersey",
                Id = "NJ"
            },
            new SystemState()
            {
                Name = "New Mexico",
                Id = "NM"
            },
            new SystemState()
            {
                Name = "New York",
                Id = "NY"
            },
            new SystemState()
            {
                Name = "North Carolina",
                Id = "NC"
            },
            new SystemState()
            {
                Name = "North Dakota",
                Id = "ND"
            },
            new SystemState()
            {
                Name = "Northern Mariana Islands",
                Id = "MP"
            },
            new SystemState()
            {
                Name = "Ohio",
                Id = "OH"
            },
            new SystemState()
            {
                Name = "Oklahoma",
                Id = "OK"
            },
            new SystemState()
            {
                Name = "Oregon",
                Id = "OR"
            },
            new SystemState()
            {
                Name = "Palau",
                Id = "PW"
            },
            new SystemState()
            {
                Name = "Pennsylvania",
                Id = "PA"
            },
            new SystemState()
            {
                Name = "Puerto Rico",
                Id = "PR"
            },
            new SystemState()
            {
                Name = "Rhode Island",
                Id = "RI"
            },
            new SystemState()
            {
                Name = "South Carolina",
                Id = "SC"
            },
            new SystemState()
            {
                Name = "South Dakota",
                Id = "SD"
            },
            new SystemState()
            {
                Name = "Tennessee",
                Id = "TN"
            },
            new SystemState()
            {
                Name = "Texas",
                Id = "TX"
            },
            new SystemState()
            {
                Name = "Utah",
                Id = "UT"
            },
            new SystemState()
            {
                Name = "Vermont",
                Id = "VT"
            },
            new SystemState()
            {
                Name = "Virgin Islands",
                Id = "VI"
            },
            new SystemState()
            {
                Name = "Virginia",
                Id = "VA"
            },
            new SystemState()
            {
                Name = "Washington",
                Id = "WA"
            },
            new SystemState()
            {
                Name = "West Virginia",
                Id = "WV"
            },
            new SystemState()
            {
                Name = "Wisconsin",
                Id = "WI"
            },
            new SystemState()
            {
                Name = "Wyoming",
                Id = "WY"
            }
            );
#endregion
    }
}
