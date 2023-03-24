using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Test, TestDTO>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<Option, OptionDTO>().ReverseMap();
        }
    }
}
