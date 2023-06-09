using System.Text.RegularExpressions;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.Idea.Create;
using MercuryProject.Domain.Common.Errors;


namespace MercuryProject.Application.Idea.Commands.Create
{
    public class IdeaCreateCommandHandler : IRequestHandler<IdeaCreateCommand, ErrorOr<IdeaResult>>
    {
        private readonly IIdeaRepository _ideaRepository;
        private readonly IUserRepository _userRepository;

        public IdeaCreateCommandHandler(IIdeaRepository ideaRepository, IUserRepository userRepository)
        {
            _ideaRepository = ideaRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IdeaResult>> Handle(IdeaCreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (await _ideaRepository.GetIdeaByTitle(request.Title) is not null)
            {
                return Errors.Idea.DuplicateIdeaName;
            }

            List<string> pathsToImage = new();

            if (request.Files != null && request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    if (file.Length > 0)
                    {
                        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                        string solutionPath = projectPath;
                        while (!Directory.GetFiles(solutionPath, "*.sln").Any())
                        {
                            solutionPath = Directory.GetParent(solutionPath)?.FullName;
                            if (solutionPath == null)
                            {
                                break;
                            }
                        }

                        string folderPath = Directory.GetParent(solutionPath).FullName;
                        string targetFolderPath = "MercuryProject-frontend-Own\\src\\resources";
                        string absolutePath = Path.Combine(folderPath, targetFolderPath);
                        string saveFolderName =  Path.Combine("ideaImages", Regex.Replace(request.Title, @"[^0-9a-zA-Z ]+", "").Replace(" ", "_"));

                        string uploadPath = Path.Combine(absolutePath, saveFolderName);

                        // Путь для сохранения файла на диске
                        string filePath = Path.Combine(uploadPath, file.FileName);

                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        pathsToImage.Add(Path.Combine(saveFolderName, file.FileName).Replace("\\", "/"));
                    }
                }
            }

            var userId = _userRepository.GetUserId();

            var idea = Domain.Idea.Idea.Create(
                userId,
                request.Title,
                request.Description,
                request.Goal,
                request.Category,
                pathsToImage);

            _ideaRepository.Add(idea);

            return new IdeaResult(idea);

        }
    }
}
