namespace aoc.D07
{
  public class Instruction
  {
    private Wire? _output;
    private Wire? _input1;
    private Wire? _input2;
    private ushort _constInput;
    private Ops _op;

    public Instruction()
    {
      _output = null;
      _input1 = null;
      _input2 = null;
      _op = Ops.NONE;
    }

    public Wire? Output { get => _output; set => _output = value; }
    public Wire? Input1 { get => _input1; set => _input1 = value; }
    public Wire? Input2 { get => _input2; set => _input2 = value; }
    public Ops Op { get => _op; set => _op = value; }
    public ushort ConstInput { get => _constInput; set => _constInput = value; }

    public void Execute(List<Wire> wires)
    {
      Wire? i1 = null;
      Wire? i2 = null;
      Wire? o = null;

      if (Input1 != null)
        i1 = wires.Find(w => w.Id == Input1.Id);
      if (Input2 != null)
        i2 = wires.Find(w => w.Id == Input2.Id);
      if (Output != null)
        o = wires.Find(w => w.Id == Output.Id);

      switch (Op)
      {
        case Ops.NOT:
          if ((o != null) && (i1!= null))
            o.Signal = (ushort)~i1.Signal;
          break;

        case Ops.OR:
          ushort temp;

          if (i1 == null)
            temp = _constInput;
          else
            temp = i1.Signal;

          if ((o != null) && (i2 != null))
            o.Signal = (ushort)((int)temp | (int)i2.Signal);
          break;

        case Ops.AND:
          if (i1 == null)
            temp = _constInput;
          else
            temp = i1.Signal;

          if ((o != null) && (i2 != null))
            o.Signal = (ushort)((int)temp & (int)i2.Signal);
          break;

        case Ops.LSHIFT:
          if ((o != null) && (i1 != null))
            o.Signal = (ushort)((int)i1.Signal << (int)ConstInput);
          break;

        case Ops.RSHIFT:
          if ((o != null) && (i1 != null))
            o.Signal = (ushort)((int)i1.Signal >> (int)ConstInput);
          break;

        case Ops.NONE:
          if (o != null)
          {
            if (i1 == null)
              o.Signal = _constInput;
            else
              o.Signal = i1.Signal;
          }
          break;

        case Ops.UNKNOWN:
        default:
          throw new Exception("Did not expect this!");
      }
    }
  }
}
