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
        public string ReferenceNo { get; set; }

        public string PackageName { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public string ScopeOfWork { get; set; }

        public string Technical_Specification { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notesheet, EditNotesheetCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
