namespace Commander.Dtos{
  public class CommandReadDto
  {
    public int Id { get; set; }
    public string HowTo { get; set; }
    public string Line { get; set; }
    // hide implementational detail from clients (for the purpose of illustration)
    // public string Platform { get; set; }
  }
}