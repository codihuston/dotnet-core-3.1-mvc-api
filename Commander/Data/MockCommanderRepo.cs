using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public IEnumerable<Command> GetAppCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Booil an egg", Line="Boil water", Platform="Kettle & Pan"},
        new Command{Id=0, HowTo="Cut Bread", Line="Get a knife", Platform="Knife & Chopping Board"},
        new Command{Id=0, HowTo="Make cup of te", Line="Place teabag in cup", Platform="Kettle & Cup"}
      };

      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command{Id=0, HowTo="Booil an egg", Line="Boil water", Platform="Kettle & Pan"};
    }
  }
}