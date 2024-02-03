using Data.Dbcontext;
using Domain.Entities._1Information.Myskills;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class MySkillRepository : IMySkillRepository
    {
        #region Ctor
        private readonly ResumeDbContext _context;
        public MySkillRepository(ResumeDbContext resumeDbContext)
        {
            _context = resumeDbContext;
        }
        #endregion

        #region General
        public async Task<List<Myskills>> GetMyskillsAsync(CancellationToken cancellationToken)
        {
            return await _context.myskills.ToListAsync(cancellationToken);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Myskills myskills)
        {
            _context.myskills.Update(myskills);
        }
        #endregion

        #region Admin Side

        public async Task<Myskills?> GetSkillById(int SkillId)
        {
            return await _context.myskills.FindAsync(SkillId);
        }

        public async Task AddSkillToDatabase(Myskills myskills)
        {
            await _context.myskills.AddAsync(myskills);
        }

        public async Task DeleteSkill(Myskills myskills)
        {
             _context.myskills.Remove(myskills);

        }
        #endregion




    }
}
