using System;

namespace FootballLeague.Services.Implementation.Match.Validators.Delete.Models
{
    public class DeleteSportMachValidationModel
    {
        public DeleteSportMachValidationModel(DateTime? endDate)
        {
            EndDate = endDate;
        }

        public DateTime? EndDate { get; }
    }
}
