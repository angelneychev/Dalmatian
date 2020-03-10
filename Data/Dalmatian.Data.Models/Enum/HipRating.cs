namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore.Diagnostics;

    public enum HipRating
    {
        [Display(Name = "OFA - Normal")]
        OfaNormal = 10,
        [Display(Name = "OFA - Excellent")]
        OfaExcellent = 20,
        [Display(Name = "OFA - Good")]
        OfaGood = 30,
        [Display(Name = "OFA - Fair")]
        OfaFair = 40,
        [Display(Name = "OFA - Borderline")]
        OfaBorderline = 50,
        [Display(Name = "OFA - Mild")]
        OfaMild = 60,
        [Display(Name = "OFA - Moderate")]
        OfaModerate = 70,
        [Display(Name = "OFA - Severe")]
        OfaSevere = 80,
        [Display(Name = "FCI - A1")]
        FciA1 = 90,
        [Display(Name = "FCI - A2")]
        FciA2 = 100,
        [Display(Name = "FCI - B1")]
        FciB1 = 110,
        [Display(Name = "FCI - B2")]
        FciB2 = 120,
        [Display(Name = "FCI - C1 (Borderline, Mild)")]
        FciC1 = 130,
        [Display(Name = "FCI - C2 (Borderline, Mild)")]
        FciC2 = 140,
        [Display(Name = "FCI - D1 (Dysplastic, Mild)")]
        FciD1 = 150,
        [Display(Name = "FCI - D2 (Dysplastic, Mild)")]
        FciD2 = 160,
        [Display(Name = "FCI - E1 (Dysplastic, Severe)")]
        FciE1 = 170,
        [Display(Name = "FCI - E2 (Dysplastic, Severe)")]
        FciE2 = 180,
        [Display(Name = "SV - a1 (a-normal)")]
        SvA1 = 190,
        [Display(Name = "SV - a2 (a-fast normal)")]
        SvA2 = 200,
        [Display(Name = "SV - a3 (a-noch zugelassen)")]
        SvA3 = 210,
        [Display(Name = "SV - a4 (Dysplastic, Mild)")]
        SvA4 = 220,
        [Display(Name = "SV - a5 (Dysplastic, Severe)")]
        SvA5 = 230,
        [Display(Name = "SV - a6 (a-Ausland)")]
        SvA6 = 240,
    }
}
