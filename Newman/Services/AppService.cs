using Microsoft.EntityFrameworkCore;
using Newman.EntityModels;
using Newman.EntityModels.Models;
using Newman.Helpers;
using Newman.Models;

namespace Newman.Services
{
    public interface IAppService
    {
        public Task<List<People>> Get(int? id);
        public Task Post(PeopleCreateModel model);
        public Task Delete(int id);
        public Task Update(PeopleUpdateModel model);
    }
    public class AppService :BaseService, IAppService
    {
        public AppService(NewmanContext context):base(context) { }
    
        public async Task<List<People>> Get(int? id)
        {
            try
            {
                var query = Context.Persons.Include(i=>i.Possessions).AsQueryable();
                if (id.HasValue)
                {
                    query = query.Where(x => x.Id == id);
                }
                var list = await query.ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                throw new GenericException(e.Message);
            }
        }

        public async Task Post(PeopleCreateModel model)
        {
            try
            {
                var newPerson = new People
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                if(model.Possessions.Count > 0)
                {
                    newPerson.Possessions = new List<Possession>();
                    newPerson.Possessions.AddRange(model.Possessions.Select(x => new Possession { Name = x }).ToList());
                }
                Context.Persons.Add(newPerson);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new GenericException(e.Message);
            }

        }

        public async Task Delete(int id)
        {
            var person = await Context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            NotFoundException.Check(person, id);
            try
            {
                Context.Persons.Remove(person!);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new GenericException(e.Message);
            }

        }

        public async Task Update(PeopleUpdateModel model)
        {
            var person = await Context.Persons.FirstOrDefaultAsync(x => x.Id == model.Id);
            NotFoundException.Check(person, model.Id);
            try
            {
                person!.FirstName = model.FirstName;
                person.LastName = model.LastName;
                Context.Persons.Update(person);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new GenericException(e.Message);
            }


        }
    }
}
