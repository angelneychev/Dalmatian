﻿namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class HealthInformationViewModel : IMapFrom<HealthInformation>
    {
    public int Id { get; set; }

    public Baer Baer { get; set; }

    public HipRating HipRating { get; set; }

    public ElbowRating ElbowRating { get; set; }

    public string OtherHealthTest { get; set; }

    public virtual ICollection<Dog> Dogs { get; set; }
    }
}