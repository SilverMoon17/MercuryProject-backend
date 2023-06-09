using Azure.Core;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly MercuryProjectDbContext _dbContext;

        public IdeaRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Idea?> GetIdeaByTitle(string title)
        {
            return await _dbContext.Set<Idea>().FirstOrDefaultAsync(u => u.Title == title);
        }

        public async Task<Idea?> GetIdeaById(Guid id)
        {
            var ideaId = IdeaId.Create(id);
            var idea = await _dbContext.Set<Idea>().FirstOrDefaultAsync(p => p.Id == ideaId);

            return idea;
        }

        public async Task<bool> DeleteIdea(Idea idea)
        {
            try
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

                string saveFolderName = Path.Combine("ideaImages", Regex.Replace(idea.Title, @"[^0-9a-zA-Z ]+", "").Replace(" ", "_"));

                string uploadPath = Path.Combine(absolutePath, saveFolderName);

                if (Directory.Exists(uploadPath))
                {
                    Directory.Delete(uploadPath, true);
                }
                _dbContext.Remove(idea);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Idea>> GetAllIdeasAsync()
        {
            var ideas = await _dbContext.Set<Idea>().ToListAsync();
            return await _dbContext.Set<Idea>().ToListAsync();
        }

        public async Task<IEnumerable<Idea>> GetAllWhereAsync(Expression<Func<Idea, bool>> predicate)
        {
            return await _dbContext.Set<Idea>().Where(predicate).ToListAsync();
        }

        public void UpdateIdeaCollectedMoney(Idea idea, decimal donate)
        {
            idea.Collected += donate;
            idea.UpdatedDateTime = DateTime.Now;
            _dbContext.Update(idea);
            _dbContext.SaveChanges();
        }

        public void UpdateIdeaStatus(Idea idea, IdeaStatus status)
        {
            idea.Status = status;
            idea.UpdatedDateTime = DateTime.Now;
            _dbContext.Update(idea);
            _dbContext.SaveChanges();
        }

        public void Add(Idea idea)
        {
            _dbContext.Add(idea);
            _dbContext.SaveChanges();
        }
    }
}
