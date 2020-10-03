using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var models = _context.Commands.ToList();
            return models;
        }

        public Command GetCommandById(int id)
        {
            var models = _context.Commands.FirstOrDefault(p => p.Id == id);
            return models;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}