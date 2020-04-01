namespace BitwiseLogic
{
  public class Instruction
  {
    private Wire _output;
    private Wire _input1;
    private Wire _input2;
    private ushort _constInput;
    private Ops _op;

    public Instruction()
    {
      _output = null;
      _input1 = null;
      _input2 = null;
      _op = Ops.NONE;
    }

    public Wire Output { get => _output; set => _output = value; }
    public Wire Input1 { get => _input1; set => _input1 = value; }
    public Wire Input2 { get => _input2; set => _input2 = value; }
    public Ops Op { get => _op; set => _op = value; }
    public ushort ConstInput { get => _constInput; set => _constInput = value; }

    public void Execute()
    {
      
    }
  }
}
