using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Behaviors.Tests.ModifyQuestion;

public class ModifyQuestionHandler : IRequestHandler<ModifyQuestionCommand>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ModifyQuestionHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(ModifyQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions
            .Include(t => t.Options)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (question is null)
        {
            throw new Exception("Question not found");
        }

        question.QuestionDescription = request.Text;

        List<Option> mappedOptions = new List<Option>();

        foreach (var option in request.Options)
        {
            var mappedOption = _mapper.Map<Option>(option);
            mappedOption.QuestionId = question.Id;

            mappedOptions.Add(mappedOption);
        }

        question.Options = mappedOptions;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
