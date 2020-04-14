using FirstComputer.Enum;

namespace FirstComputer
{
  public class Instruction
  {
    private OpCode _opCode;
    private string _op1;
    private string _op2;

    public Instruction(OpCode opCode = OpCode.Unknown, string op1 = null, string op2 = null)
    {
      _opCode = opCode;      
      _op1 = op1;
      _op2 = op2;
    }

    public OpCode OpCode { get => _opCode; set => _opCode = value; }
    public string Op1 { get => _op1; set => _op1 = value; }
    public string Op2 { get => _op2; set => _op2 = value; }
  }
}
