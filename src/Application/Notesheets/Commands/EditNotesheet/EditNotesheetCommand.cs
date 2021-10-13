using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.Notesheets.Commands.EditNotesheet
{
   public class EditNotesheetCommand : IRequest<List<string>>, IMapFrom<Notesheet>
    {
        public int Id { get; set; }
        public string IndentingDept { get; set; }
        public string ReferenceNo { get; set; }

        public string PackageName { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public string ScopeOfWork { get; set; }

        public string Technical_Specification { get; set; }

        public float EstimatedCost { get; set; }

        public string BudgetOfferReference { get; set; }

        public DateTime BudgetOfferDate { get; set; }

        public string BudgetOfferValidity { get; set; }

        public string BudgetOfferAddress { get; set; }

        public string BillOfQuantity { get; set; }

        public string Guarantee_Warranty { get; set; }

        public string Payment_Terms_CPG { get; set; }

        public string ModeOfTerm { get; set; }
        public string ReasonsForModeOfTender { get; set; }

        public string ProprietaryArticleCertificate { get; set; }

        public string TypeOfBidding { get; set; }

        public string ListOfParties { get; set; }

        public string GeMNonAvailabilityCertificate { get; set; }

        public string WorkCompletionSchedule { get; set; }

        public string SpecialConditionsOfContract { get; set; }

        public string OtherPointsRelevantWithCase { get; set; }

        public string BudgetProvision { get; set; }
        public string BPSerialNo { get; set; }  
        public string BPUnderHead { get; set; } 

        public string DopClause { get; set; }
        public string DopSection { get; set; } 
        public string ApprovingAuthority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notesheet, EditNotesheetCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
