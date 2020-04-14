using FirstComputer.Enum;
using System;

namespace FirstComputer
{
  public class Computer
  {
    private uint _a;
    private uint _b;
    private int _ip;                //unless program has a bug, this wont go negative but using int instead of uint to avoid useless typecasts all over
    private readonly Instruction[] _program;

    public uint B { get => _b; set => _b = value; }

    public Computer(Instruction[] program, bool isPartII = false)
    {
      _program = program;

      if (isPartII)
        _a = 1;
      else
        _a = 0;

      _b = 0;
      _ip = 0;
    }

    public void Execute()
    {
      var exited = false;

      while (!exited)
      {
        var curr = _program[_ip];

        switch (curr.OpCode)
        {
          case OpCode.Half:
            Half(curr.Op1);
            break;
          case OpCode.Triple:
            Triple(curr.Op1);
            break;
          case OpCode.Increment:
            Increment(curr.Op1);
            break;
          case OpCode.Jump:
            Jump(curr.Op1);
            break;
          case OpCode.JumpIfEven:
            JumpIfEven(curr.Op1, curr.Op2);
            break;
          case OpCode.JumpIfOne:
            JumpIfOne(curr.Op1, curr.Op2);
            break;
          case OpCode.Exit:
            exited = true;
            break;
          case OpCode.Unknown:
          default:
            throw new Exception("Should not have happened!!");
        }
      }

      //reset _ip etc. here
    }

    private void Half(string op1)
    {
      var c = op1[0];

      switch (c)
      {
        case 'a':
          _a /= 2;
          break;
        case 'b':
          _b /= 2;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Triple(string op1)
    {
      var c = op1[0];

      switch (c)
      {
        case 'a':
          _a *= 3;
          break;
        case 'b':
          _b *= 3;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Increment(string op1)
    {
      var c = op1[0];

      switch (c)
      {
        case 'a':
          _a++;
          break;
        case 'b':
          _b++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Jump(string op1)
    {
      var offset = int.Parse(op1);
      _ip += offset;
    }

    private void JumpIfEven(string op1, string op2)
    {
      var c = op1[0];
      var offset = int.Parse(op2);

      switch (c)
      {
        case 'a':
          if (_a % 2 == 0)
            _ip += offset;
          else
            _ip++;
          break;
        case 'b':
          if (_b % 2 == 0)
            _ip += offset;
          else
            _ip++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }
    }

    private void JumpIfOne(string op1, string op2)
    {
      var c = op1[0];
      var offset = int.Parse(op2);

      switch (c)
      {
        case 'a':
          if (_a == 1)
            _ip += offset;
          else
            _ip++;
          break;
        case 'b':
          if (_b == 1)
            _ip += offset;
          else
            _ip++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }
    }
  }
}
