namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore.Diagnostics;

    public enum HipRating
    {
        [Display(Name = "Not available")]
        Not_available = 0,

        [Display(Name = "OFA - Normal")]
        OFA_Normal = 10,
        [Display(Name = "OFA - Excellent")]
        OFA_Excellent = 20,
        [Display(Name = "OFA - Good")]
        OFA_Good = 30,
        [Display(Name = "OFA - Fair")]
        OFA_Fair = 40,
        [Display(Name = "OFA - Borderline")]
        OFA_Borderline = 50,
        [Display(Name = "OFA - Mild")]
        OFA_Mild = 60,
        [Display(Name = "OFA - Moderate")]
        OFA_Moderate = 70,
        [Display(Name = "OFA - Severe")]
        OFA_Severe = 80,
        [Display(Name = "FCI - A1")]
        FCI_A1 = 90,
        [Display(Name = "FCI - A2")]
        FCI_A2 = 100,
        [Display(Name = "FCI - B1")]
        FCI_B1 = 110,
        [Display(Name = "FCI - B2")]
        FCI_B2 = 120,
        [Display(Name = "FCI - C1 (Borderline, Mild)")]
        FCI_C1 = 130,
        [Display(Name = "FCI - C2 (Borderline, Mild)")]
        FCI_C2 = 140,
        [Display(Name = "FCI - D1 (Dysplastic, Mild)")]
        FCI_D1 = 150,
        [Display(Name = "FCI - D2 (Dysplastic, Mild)")]
        FCI_D2 = 160,
        [Display(Name = "FCI - E1 (Dysplastic, Severe)")]
        FCI_E1 = 170,
        [Display(Name = "FCI - E2 (Dysplastic, Severe)")]
        FCI_E2 = 180,
        [Display(Name = "SV - a1 (a-normal)")]
        SV_a1 = 190,
        [Display(Name = "SV - a2 (a-fast normal)")]
        SV_a2 = 200,
        [Display(Name = "SV - a3 (a-noch zugelassen)")]
        SV_a3 = 210,
        [Display(Name = "SV - a4 (Dysplastic, Mild)")]
        SV_a4 = 220,
        [Display(Name = "SV - a5 (Dysplastic, Severe)")]
        SV_a5 = 230,
        [Display(Name = "SV - a6 (a-Ausland)")]
        SV_a6 = 240,
    }
}
