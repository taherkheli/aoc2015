namespace aoc.D23
{
  public class Instruction(OpCode opCode = OpCode.Unknown, string op1 = "", string op2 = "")
  {
    private OpCode _opCode = opCode;
    private string _op1 = op1;
    private string _op2 = op2;

    public OpCode OpCode { get => _opCode; set => _opCode = value; }
    public string Op1 { get => _op1; set => _op1 = value; }
    public string Op2 { get => _op2; set => _op2 = value; }
  }
}
