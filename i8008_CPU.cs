using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace i8008_emu
{
    class Instruction
    {
        private Func<byte> action;
        private string mnemonic;
        private byte length;

        public string Mnemonic
        {
            get
            {
                return mnemonic;
            }
        }

        public Func<byte> Action
        {
            get
            {
                return action;
            }
        }

        public byte Length
        {
            get
            {
                return length;
            }
        }


        public Instruction(Func<byte> action_arg, string mnemonic_arg, byte lenght_arg)
        {
            action = action_arg;
            mnemonic = mnemonic_arg;
            length = lenght_arg;
        }
    }
    class i8008_CPU
    {
        private Instruction[] instructions;
        private byte[] memory = new byte[14 * 1024];
        private byte[] registers = new byte[7];
        private bool[] flags = new bool[4];
        private UInt16[] stack = new UInt16[7];
        private byte[] ports = new byte[32];

        private byte SP = 0;
        private UInt16 PC = 0;
        private byte cycles = 0;
        private enum Flags {C = 0, P, Z, S};
        private enum Registers {A = 0, B, C, D, E, H, L};
        private bool halted = false;
        private byte currentOpcode;

        private i8008_emu_GUI.MainForm mainForm;

        public bool Halted
        {
            get
            {
                return this.halted;
            }
        }

        public byte Cycles
        {
            get
            {
                return this.cycles;
            }
        }

        public UInt16 ProgramCounter
        {
            get
            {
                return this.PC;
            }
        }

        public byte StackPointer
        {
            get
            {
                return this.SP;
            }
        }

        public i8008_CPU (i8008_emu_GUI.MainForm mainForm_arg)
        {
            mainForm = mainForm_arg;
            cycles = 20;
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = 0xFF;
            }

            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = 0;
            }

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i] = false;
            }

            instructions = new Instruction[256] 
            {
                new Instruction(HLT, "HLT", 1), new Instruction(HLT, "HLT",1 ), new Instruction(RLC, "RCL", 1), new Instruction(RFC, "RFC", 1), new Instruction(ADI, "ADI", 2), new Instruction(RST_0, "RST 0", 1), new Instruction(LRI, "LAI", 2), new Instruction(RET, "RET", 1), new Instruction(INR, "INB", 1), new Instruction(DCR, "DCB", 1), new Instruction(RRC, "RRC", 1), new Instruction(RFZ, "RFZ", 1), new Instruction(ACI, "ACI", 2), new Instruction(RST_1, "RTS 1", 1), new Instruction(LRI, "LBI", 2), new Instruction(RET, "RET", 1),
                new Instruction(INR, "INC", 1), new Instruction(DCR, "DCC", 1), new Instruction(RAL, "RAL", 1), new Instruction(RFS, "RFS", 1), new Instruction(SUI, "SUI", 2), new Instruction(RST_2, "RST 2", 1), new Instruction(LRI, "LCI", 2), new Instruction(RET, "RET", 1), new Instruction(INR, "IND", 1), new Instruction(DCR, "DCD", 1), new Instruction(RAR, "RAR", 1), new Instruction(RFP, "RFP", 1), new Instruction(SBI, "SBI", 2), new Instruction(RST_3, "RST 3", 1), new Instruction(LRI, "LDI", 2), new Instruction(RET, "RET", 1),
                new Instruction(INR, "INE", 1), new Instruction(DCR, "DCE", 1), new Instruction(XXX, "???", 1), new Instruction(RTC, "RTC", 1), new Instruction(NDI, "NDI", 2), new Instruction(RST_4, "RST 4", 1), new Instruction(LRI, "LEI", 2), new Instruction(RET, "RET", 1), new Instruction(INR, "INH", 1), new Instruction(DCR, "DCH", 1), new Instruction(XXX, "???", 1), new Instruction(RTZ, "RTZ", 1), new Instruction(XRI, "XRI", 2), new Instruction(RST_5, "RST 5", 1), new Instruction(LRI, "LHI", 2), new Instruction(RET, "RET", 1),
                new Instruction(INR, "INL", 1), new Instruction(DCR, "DCL", 1), new Instruction(XXX, "???", 1), new Instruction(RTS, "RTS", 1), new Instruction(ORI, "ORI", 2), new Instruction(RST_6, "RST 6", 1), new Instruction(LRI, "LLI", 2), new Instruction(RET, "RET", 1), new Instruction(XXX, "???", 1), new Instruction(XXX, "???", 1), new Instruction(XXX, "???", 1), new Instruction(RTP, "RTP", 1), new Instruction(CPI, "CPI", 2), new Instruction(RST_7, "RST 7", 1), new Instruction(LMI, "LMI", 2), new Instruction(RET, "RET", 1),
                new Instruction(JFC, "JFC", 3), new Instruction(INP, "INP 0", 1), new Instruction(CFC, "CFC", 3), new Instruction(INP, "INP 1", 1), new Instruction(JMP, "JMP", 3), new Instruction(INP, "INP 2", 1),     new Instruction(CAL, "CAL", 3), new Instruction(INP, "INP 3", 1), new Instruction(JFZ, "JFZ", 3), new Instruction(INP, "INP 4", 1), new Instruction(CFZ, "CFZ", 3), new Instruction(INP, "INP 5", 1), new Instruction(JMP, "JMP", 3), new Instruction(INP, "INP 6", 1),     new Instruction(CAL, "CAL", 3), new Instruction(INP, "INP 7", 1),
                new Instruction(JFS, "JFS", 3), new Instruction(OUT, "OUT 8", 1), new Instruction(CFS, "CFS", 3), new Instruction(OUT, "OUT 9", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 10", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 11", 1), new Instruction(JFP, "JFP", 3), new Instruction(OUT, "OUT 12", 1), new Instruction(CFP, "CFP", 3), new Instruction(OUT, "OUT 13", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 14", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 15", 1),
                new Instruction(JTC, "JTC", 3), new Instruction(OUT, "OUT 16", 1), new Instruction(CTC, "CTC", 3), new Instruction(OUT, "OUT 17", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 18", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 19", 1), new Instruction(JTZ, "JTZ", 3), new Instruction(OUT, "OUT 20", 1), new Instruction(CTZ, "CTZ", 3), new Instruction(OUT, "OUT 21", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 22", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 23", 1),
                new Instruction(JTS, "JTS", 3), new Instruction(OUT, "OUT 24", 1), new Instruction(CTS, "CTS", 3), new Instruction(OUT, "OUT 25", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 26", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 27", 1), new Instruction(JTP, "JTP", 3), new Instruction(OUT, "OUT 28", 1), new Instruction(CTP, "CTP", 3), new Instruction(OUT, "OUT 29", 1), new Instruction(JMP, "JMP", 3), new Instruction(OUT, "OUT 30", 1),     new Instruction(CAL, "CAL", 3), new Instruction(OUT, "OUT 31", 1),
                new Instruction(ADR, "ADA", 1), new Instruction(ADR, "ADB", 1), new Instruction(ADR, "ADC", 1), new Instruction(ADR, "ADD", 1), new Instruction(ADR, "ADE", 1), new Instruction(ADR, "ADH", 1),     new Instruction(ADR, "ADL", 1), new Instruction(ADM, "ADM", 1), new Instruction(ACR, "ACA", 1), new Instruction(ACR, "ACB", 1), new Instruction(ACR, "ACC", 1), new Instruction(ACR, "ACD", 1), new Instruction(ACR, "ACE", 1), new Instruction(ACR, "ACH", 1),     new Instruction(ACR, "ACL", 1), new Instruction(ACM, "ACM", 1), 
                new Instruction(SUR, "SUA", 1), new Instruction(SUR, "SUB", 1), new Instruction(SUR, "SUC", 1), new Instruction(SUR, "SUD", 1), new Instruction(SUR, "SUE", 1), new Instruction(SUR, "SUH", 1),     new Instruction(SUR, "SUL", 1), new Instruction(SUM, "SUM", 1), new Instruction(SBR, "SBA", 1), new Instruction(SBR, "SBB", 1), new Instruction(SBR, "SBC", 1), new Instruction(SBR, "SBD", 1), new Instruction(SBR, "SBE", 1), new Instruction(SBR, "SBH", 1),     new Instruction(SBR, "SBL", 1), new Instruction(SBM, "SBM", 1),
                new Instruction(NDR, "NDA", 1), new Instruction(NDR, "NDB", 1), new Instruction(NDR, "NDC", 1), new Instruction(NDR, "NDD", 1), new Instruction(NDR, "NDE", 1), new Instruction(NDR, "NDH", 1),     new Instruction(NDR, "NDL", 1), new Instruction(NDM, "NDM", 1), new Instruction(XRR, "XRA", 1), new Instruction(XRR, "XRB", 1), new Instruction(XRR, "XRC", 1), new Instruction(XRR, "XRD", 1), new Instruction(XRR, "XRE", 1), new Instruction(XRR, "XRH", 1),     new Instruction(XRR, "XRL", 1), new Instruction(XRM, "XRM", 1),
                new Instruction(ORR, "ORA", 1), new Instruction(ORR, "ORB", 1), new Instruction(ORR, "ORC", 1), new Instruction(ORR, "ORD", 1), new Instruction(ORR, "ORE", 1), new Instruction(ORR, "ORH", 1),     new Instruction(ORR, "ORL", 1), new Instruction(ORM, "ORM", 1), new Instruction(CPR, "CPA", 1), new Instruction(CPR, "CPB", 1), new Instruction(CPR, "CPC", 1), new Instruction(CPR, "CPD", 1), new Instruction(CPR, "CPE", 1), new Instruction(CPR, "CPH", 1),     new Instruction(CPR, "CPL", 1), new Instruction(CPM, "CPM", 1),
                new Instruction(NOP, "NOP", 1), new Instruction(LRdRs, "LAB", 1), new Instruction(LRdRs, "LAC", 1), new Instruction(LRdRs, "LAD", 1), new Instruction(LRdRs, "LAE", 1), new Instruction(LRdRs, "LAH", 1), new Instruction(LRdRs, "LAL", 1), new Instruction(LRdM, "LAM", 1), new Instruction(LRdRs, "LBA", 1), new Instruction(LRdRs, "LBB", 1), new Instruction(LRdRs, "LBC", 1), new Instruction(LRdRs, "LBD", 1), new Instruction(LRdRs, "LBE", 1), new Instruction(LRdRs, "LBH", 1), new Instruction(LRdRs, "LBL", 1), new Instruction(LRdM, "LBM", 1),
                new Instruction(LRdRs, "LCA", 1), new Instruction(LRdRs, "LCB", 1), new Instruction(LRdRs, "LCC", 1), new Instruction(LRdRs, "LCD", 1), new Instruction(LRdRs, "LCE", 1), new Instruction(LRdRs, "LCH", 1), new Instruction(LRdRs, "LCL", 1), new Instruction(LRdM, "LCM", 1), new Instruction(LRdRs, "LDA", 1), new Instruction(LRdRs, "LDB", 1), new Instruction(LRdRs, "LDC", 1), new Instruction(LRdRs, "LDD", 1), new Instruction(LRdRs, "LDE", 1), new Instruction(LRdRs, "LDH", 1), new Instruction(LRdRs, "LDL", 1), new Instruction(LRdM, "LDM", 1),
                new Instruction(LRdRs, "LEA", 1), new Instruction(LRdRs, "LEB", 1), new Instruction(LRdRs, "LEC", 1), new Instruction(LRdRs, "LED", 1), new Instruction(LRdRs, "LEE", 1), new Instruction(LRdRs, "LEH", 1), new Instruction(LRdRs, "LEL", 1), new Instruction(LRdM, "LEM", 1), new Instruction(LRdRs, "LHA", 1), new Instruction(LRdRs, "LHB", 1), new Instruction(LRdRs, "LHC", 1), new Instruction(LRdRs, "LHD", 1), new Instruction(LRdRs, "LHE", 1), new Instruction(LRdRs, "LHH", 1), new Instruction(LRdRs, "LHL", 1), new Instruction(LRdM, "LHM", 1),
                new Instruction(LRdRs, "LLA", 1), new Instruction(LRdRs, "LLB", 1), new Instruction(LRdRs, "LLC", 1), new Instruction(LRdRs, "LLD", 1), new Instruction(LRdRs, "LLE", 1), new Instruction(LRdRs, "LLH", 1), new Instruction(LRdRs, "LLL", 1), new Instruction(LRdM, "LLM", 1), new Instruction(LMRs, "LMA", 1), new Instruction(LMRs, "LMB", 1), new Instruction(LMRs, "LMC", 1), new Instruction(LMRs, "LMD", 1), new Instruction(LMRs, "LME", 1), new Instruction(LMRs, "LMH", 1), new Instruction(LMRs, "LML", 1), new Instruction(HLT, "HLT", 1)
            };
            halted = false;          
        }

        public void ResetMemory()
        {
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = 0xFF;
            }
        }

        public bool LoadMemoryFromFile(string path)
        {
            bool result = true;
            try
            {
                BinaryReader memoryFile = new BinaryReader(new FileStream(path, FileMode.Open));

                for (int i = 0; i < this.memory.Length && i < memoryFile.BaseStream.Length; i++)
                {
                    this.memory[i] = memoryFile.ReadByte();
                }

                Reset();
            }
            catch
            {
                result = false;
            }



            return result;
        }

        public string GetStack()
        {
            string stackString = "";

            for (int i = 0; i < stack.Length; i++)
            {
                stackString += i.ToString() + ": " + stack[i].ToString("X4");
                if (i == (SP & 0b111))
                {
                    stackString += " <";
                }
                stackString += "\n";
            }

            return stackString;
        }

        public byte[] GetMemoryPage(byte pageNumber)
        {
            if (pageNumber <= 56)
            {
                pageNumber--;
                byte[] page = new byte[256];

                for (int i = 0; i < 256; i++)
                {
                    page[i] = memory[pageNumber * 256 + i];
                }

                return page;
            }
            else
            {
                throw new IndexOutOfRangeException("The number of a page must be less or equal to 56 and more or equal to 1!");
            }


        }
        public string DisassembleCurrentOpcode()
        {
            Instruction currentInst = instructions[Read(PC)];
            string dissambled = currentInst.Mnemonic;
            switch(currentInst.Length)
            {
                case 2:
                    dissambled += " 0x" + Read((UInt16)(PC + 1)).ToString("X2");
                    break;

                case 3:
                    UInt16 temp = (UInt16)((Read((UInt16)(PC + 2)) << 8) | Read((UInt16)(PC + 1)));
                    dissambled += " 0x" + temp.ToString("X4");
                    break;
            }
            return dissambled;
        }

        public string GetRegisters()
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            string result = string.Empty;

            result += "A = 0x" + registers[0].ToString("X2") + " ";
            result += "B = 0x" + registers[1].ToString("X2") + " ";
            result += "C = 0x" + registers[2].ToString("X2") + " ";
            result += "D = 0x" + registers[3].ToString("X2") + " ";
            result += "E = 0x" + registers[4].ToString("X2") + "\n";
            result += "H = 0x" + registers[5].ToString("X2") + " ";
            result += "L = 0x" + registers[6].ToString("X2") + " ";
            result += "M = 0x" + Read(memoryAddress).ToString("X2");

            return result;
        }

        public string GetFalgs()
        {
            string result = "";

            result += "C = " + (GetFlag(Flags.C) ? 1 : 0).ToString();
            result += "\tZ = " + (GetFlag(Flags.Z) ? 1 : 0).ToString();
            result += "\tP = " + (GetFlag(Flags.P) ? 1 : 0).ToString();
            result += "\tS = " + (GetFlag(Flags.S) ? 1 : 0).ToString();

            return result;
        }

        public void Cycle()
        {
            if (!halted)
            {
                if (cycles == 0)
                {
                    currentOpcode = Fetch();
                    cycles = instructions[currentOpcode].Action();
                }
                else
                {
                    cycles--;
                }
            }
        }
        private byte Fetch()
        {
            byte fetched = memory[PC];
            PC++;
            return fetched;
        }

        private byte Read(UInt16 address)
        {
            address = (UInt16)(address & 0b0011111111111111);
            return memory[address];
        }
        private void Write(UInt16 address, byte value)
        {
            address = (UInt16)(address & 0b0011111111111111);
            memory[address] = value;
        }

        private void SetFlag(Flags flag, bool value)
        {
            flags[(int)flag] = value;
        }

        private bool GetFlag(Flags flag)
        {
            return flags[(int)flag];
        }

        private byte GetRegisterValue(Registers register)
        {
            return registers[(int)register];
        }

        private void SetRegisterValue(Registers register, byte value)
        {
            registers[(int)register] = value;
        }

        private bool CheckParity(byte valueToCheck)
        {
            byte placeOfTheMSB = 0;
            for (byte i = 0; i < 8; i++)
            {
                if ((valueToCheck & 1) == 1)
                {
                    placeOfTheMSB = i;
                }
                valueToCheck >>= 1;
            }
            return placeOfTheMSB % 2 == 1;
        }

        public void Reset()
        {
            SP = 0;
            PC = 0;
            cycles = 5;
            halted = false;

            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = 0;
            }

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i] = false;
            }

            for (int i = 0; i < stack.Length; i++)
            {
                stack[i] = 0;
            }
        }

        /*
         * Instructions' implementation
         * Each of these functions return number of clock cycles         
         */

        private byte INP() //reads a value from port, specified in the current opcode, and loads it into A register
        {
            byte portNumber = (byte)(currentOpcode & 0b00001110);
            portNumber >>= 1;
            SetRegisterValue(Registers.A, mainForm.ReadFromPort(portNumber));
            return 3;
        }

        private byte OUT() //writes the value of register A into the port, specified in the current opcode
        {
            byte portNumber = (byte)(currentOpcode & 0b00111110);
            portNumber >>= 1;
            mainForm.WriteToPort(portNumber, GetRegisterValue(Registers.A));
            return 2;
        }

        private byte LRdRs() //load redister Rd with the value of register Rs
        {
            byte Rd, Rs;

            Rd = (byte)(currentOpcode & 0b00111000);
            Rd >>= 3;
            Rs = (byte)(currentOpcode & 0b00000111);

            registers[Rd] = registers[Rs];

            return 1;
        }

        private byte LRdM() //load register Rd with the value at memory address, stored in registers HL
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));
            byte Rd;

            Rd = (byte)(currentOpcode & 0b00111000);
            Rd >>= 3;

            registers[Rd] = Read(memoryAddress);

            return 3;
        }

        private byte LMRs() //load memory cell at address, stored in registers HL, with the value of register Rs
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));
            byte Rs;

            Rs = (byte)(currentOpcode & 0b00000111);

            Write(memoryAddress, registers[Rs]);

            return 3;
        }

        private byte XXX() //iilegal instruction
        {
            return 2;
        }

        private byte RFZ() //return, if Zero flag = 0
        {
            byte cyclesToReturn = 0;

            if (!GetFlag(Flags.Z))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte INR() //increment register R
        {
            byte reg = (byte)(currentOpcode & 0b00111000);
            reg >>= 3;
            byte temp = (byte)(registers[reg] + 1);

            SetFlag(Flags.P, CheckParity(temp));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);

            registers[reg] = temp;
            return 1;
        }

        private byte DCR() //decrement register R
        {
            byte reg = (byte)(currentOpcode & 0b00111000);
            reg >>= 3;
            byte temp = (byte)(registers[reg] - 1);

            SetFlag(Flags.P, CheckParity(temp));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);

            registers[reg] = temp;
            return 1;
        }

        private byte LRI() //load register R with the value located next to the opcode in memory
        {
            byte reg = (byte)(currentOpcode & 0b00111000);
            reg >>= 3;

            registers[reg] = Fetch();

            return 3;
        }

        private byte HLT() //halts the CPU
        {
            halted = true;
            return 0;
        }

        private byte RLC() //rotate A left once
        {
            UInt16 temp = GetRegisterValue(Registers.A);
            temp <<= 1;
            SetFlag(Flags.C, temp > 255);
            SetRegisterValue(Registers.A, (byte)temp);
            return 2;
        }

        private byte RFC() //return, if Carry = 0
        {
            byte cyclesToReturn = 0;

            if (!GetFlag(Flags.C))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
                
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte RST_0() //call subroutine at 0b000000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (0 << 3) | 0b000;
            return 2;        
        }

        

        private byte RET() //unconditional return
        {
            SP--;
            SP &= 0b111;
            PC = stack[SP];
            stack[SP] = 0;
            return 2;
        }

        

        

        private byte RRC() //rotate A right once
        {
            UInt16 temp = GetRegisterValue(Registers.A);
            temp >>= 1;
            SetFlag(Flags.C, temp > 255);
            SetRegisterValue(Registers.A, (byte)temp);
            return 2;
        }

        private byte ADI() // A = A + the value located next to the opcode in memory
        {
            byte valueToAdd = Fetch();
            byte temp = (byte)(GetRegisterValue(Registers.A) + valueToAdd);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);
            SetFlag(Flags.P, CheckParity(temp));

            SetRegisterValue(Registers.A, temp);
            return 3;
        }

        private byte ACI() // A = Carry + the value located next to the opcode in memory
        {
            byte temp = (byte)(Fetch() + (GetFlag(Flags.C) ? 1 : 0));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);
            SetFlag(Flags.P, CheckParity(temp));

            SetRegisterValue(Registers.A, temp);
            return 3;
        }

        private byte RST_1() //call subroutine at 0b001000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (1 << 3) | 0b000;
            return 2;
        }

       

        

        


        private byte RFS() //return, if Sign flag = 0
        {
            byte cyclesToReturn = 0;

            if (!GetFlag(Flags.S))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;        
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte RAL() //rotate A left through carry once
        {
            UInt16 temp = (UInt16)GetRegisterValue(Registers.A);

            temp <<= 1;
            SetFlag(Flags.C, temp > 255);
            temp |= (GetFlag(Flags.C) ? 1 : 0);
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 2;
        }

        private byte SUI() // A = A - the value located next to the opcode in memory
        {
            byte valueToSubtract = Fetch();
            byte temp = (byte)(GetRegisterValue(Registers.A) - valueToSubtract);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);
            SetFlag(Flags.P, CheckParity(temp));

            SetRegisterValue(Registers.A, temp);
            return 3;
        }

        private byte RST_2() //call subroutine at 0b010000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (2 << 3) | 0b000;
            return 2;
        }

        

        

        private byte RAR() //rotate A right through carry once
        {
            UInt16 temp = (UInt16)GetRegisterValue(Registers.A);

            temp >>= 1;
            SetFlag(Flags.C, temp > 255);
            temp |= (GetFlag(Flags.C) ? 0x80 : 0x00);
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 2;
        }

        private byte RFP() //return, if Parity flag = 0
        {
            byte cyclesToReturn = 0;

            if (!GetFlag(Flags.P))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte SBI() // A = A - (Carry + the value located next to the opcode in memory)
        {
            byte temp = (byte)(GetRegisterValue(Registers.A) - ((GetFlag(Flags.C) ? 1 : 0) + Fetch()));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);
            SetFlag(Flags.P, CheckParity(temp));

            SetRegisterValue(Registers.A, temp);
            return 3;
        }

        private byte RST_3() //call subroutine at 0b011000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (3 << 3) | 0b000;
            return 2;
        }

        

        private byte NOP() //no operation
        {
            return 2;
        }

        

        private byte RTC() //return, if Carry = 1
        {
            byte cyclesToReturn = 0;

            if (GetFlag(Flags.C))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte NDI() // A = A & the value located next to the opcode in memory
        {
            byte temp = (byte)(GetRegisterValue(Registers.A) & Fetch());

            SetFlag(Flags.P, CheckParity(temp));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);

            SetRegisterValue(Registers.A, temp);

            return 3;
        }

        private byte RST_4() //call subroutine at 0b100000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (4 << 3) | 0b000;
            return 2;
        }

        

        

        private byte RTZ() //return, if Zero flag = 1
        {
            byte cyclesToReturn = 0;

            if (GetFlag(Flags.Z))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte XRI() // A = A ^ the value located next to the opcode in memory
        {
            byte temp = (byte)(GetRegisterValue(Registers.A) ^ Fetch());

            SetFlag(Flags.P, CheckParity(temp));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);

            SetRegisterValue(Registers.A, temp);

            return 3;
        }

        private byte RST_5() //call subroutine at 0b101000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (5 << 3) | 0b000;
            return 2;
        }

        

        

        private byte RTS() //return, if Sign flag = 1
        {
            byte cyclesToReturn = 0;

            if (GetFlag(Flags.S))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 3;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte ORI() // A = A | the value located next to the opcode in memory
        {
            byte temp = (byte)(GetRegisterValue(Registers.A) | Fetch());

            SetFlag(Flags.P, CheckParity(temp));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);

            SetRegisterValue(Registers.A, temp);

            return 3;
        }

        private byte RST_6() //call subroutine at 0b110000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (6 << 3) | 0b000;
            return 2;
        }

        

        private byte RTP() //return, if Patiy flag = 1
        {
            byte cyclesToReturn = 0;

            if (GetFlag(Flags.P))
            {
                SP--;
                SP &= 0b111;
                PC = stack[SP];
                stack[SP] = 0;
                cyclesToReturn = 2;
            }
            else
            {
                cyclesToReturn = 1;
            }

            return cyclesToReturn;
        }

        private byte CPI() //compare A with the value located next to the opcode in memory
        {
            byte temp = (byte)(GetRegisterValue(Registers.A) - Fetch());

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, temp == 0);
            SetFlag(Flags.P, CheckParity(temp));

            return 3;
        }

        private byte RST_7() //call subroutine at 0b111000
        {
            SP &= 0b111;
            stack[SP] = PC;
            SP++;
            PC = (7 << 3) | 0b000;
            return 2;
        }

        private byte LMI()
        {
            UInt16 memoryLocation = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));
            Write(memoryLocation, Fetch());
            return 3;
        }

        private byte JFC()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (!GetFlag(Flags.C))
            {               
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CFC()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (!GetFlag(Flags.C))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JMP()
        {
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            PC = addressToJumpAt;
            return 4;
        }

        private byte CAL()
        {
            SP &= 0b111;             
            byte lowPart = Fetch(), highPart = Fetch();
            stack[SP] = PC;
            SP++;
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            PC = addressToJumpAt;
            return 4;
        }

        private byte JFZ()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (!GetFlag(Flags.Z))
            {
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CFZ()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (!GetFlag(Flags.Z))
            {              
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JFS()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (!GetFlag(Flags.S))
            {                
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CFS()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (!GetFlag(Flags.S))
            {              
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JFP()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (!GetFlag(Flags.P))
            {         
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CFP()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (!GetFlag(Flags.P))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JTC()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (GetFlag(Flags.C))
            {
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CTC()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (GetFlag(Flags.C))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JTZ()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (GetFlag(Flags.Z))
            {
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CTZ()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (GetFlag(Flags.Z))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JTS()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (GetFlag(Flags.S))
            {
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CTS()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (GetFlag(Flags.S))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte JTP()
        {
            byte cyclesToReturn;
            byte lowPart = Fetch(), highPart = Fetch();
            UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
            if (GetFlag(Flags.P))
            {
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte CTP()
        {
            byte cyclesToReturn;
            SP &= 0b111;
            byte lowPart = Fetch(), highPart = Fetch();
            if (GetFlag(Flags.P))
            {
                
                stack[SP] = PC;
                SP++;
                UInt16 addressToJumpAt = (UInt16)((highPart << 8) | lowPart);
                PC = addressToJumpAt;
                cyclesToReturn = 4;
            }
            else
            {
                cyclesToReturn = 3;
            }
            return cyclesToReturn;
        }

        private byte ADR() //A = A + the value of register R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)((UInt16)GetRegisterValue(Registers.A) + (UInt16)registers[R]);

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 2;
        }

        private byte ADM() //A = A + the value of memory cell at address, stored in registers HL
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)((UInt16)GetRegisterValue(Registers.A) + (UInt16)Read(memoryAddress));

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 3;
        }

        private byte ACR() //A = Carry + the value of register R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)( (GetFlag(Flags.C) ? 1 : 0) + (UInt16)registers[R]);

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 2;
        }

        private byte ACM() //A = Carry + the value of memory cell at address, stored in registers HL
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)((GetFlag(Flags.C) ? 1 : 0) + Read(memoryAddress));

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 3;
        }

        private byte SUR() //A = A - register R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) - registers[R]);

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 2;
        }

        private byte SUM() //A = A - the value of memory cell at address, stored in registers HL
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) - Read(memoryAddress));

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 3;
        }

        private byte SBR() //A = A - (Carry + the value of register R)
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)( GetRegisterValue(Registers.A) - ((GetFlag(Flags.C) ? 1 : 0) + registers[R]));

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 2;
        }

        private byte SBM() //A = A - (Carry + the value of memory cell at address, stored in registers HL)
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) - ((GetFlag(Flags.C) ? 1 : 0) + Read(memoryAddress)));

            SetFlag(Flags.C, temp > 255);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)(temp & 0xFF)));
            SetFlag(Flags.S, (temp & 0x80) == 0x80);

            SetRegisterValue(Registers.A, (byte)(temp & 0xFF));

            return 3;
        }

        private byte NDR() //A = A & the value of register R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) & registers[R]);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 2;
        }


        private byte NDM() //A = A & M
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) & Read(memoryAddress));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 3;
        }

        private byte XRR() //A = A ^ R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) ^ registers[R]);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 2;
        }

        private byte XRM() //A = A ^ M
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) ^ Read(memoryAddress));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 3;
        }

        private byte ORR() //A = A | R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) | registers[R]);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 2;
        }

        private byte ORM() //A = A | M
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) | Read(memoryAddress));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            SetRegisterValue(Registers.A, (byte)temp);

            return 3;
        }

        private byte CPR() //compare A with R
        {
            byte R;
            R = (byte)(currentOpcode & 0b00000111);

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) - registers[R]);

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            return 2;
        }

        private byte CPM()
        {
            UInt16 memoryAddress = (UInt16)((GetRegisterValue(Registers.H) << 8) | GetRegisterValue(Registers.L));

            UInt16 temp = (UInt16)(GetRegisterValue(Registers.A) - Read(memoryAddress));

            SetFlag(Flags.S, (temp & 0x80) == 0x80);
            SetFlag(Flags.Z, (temp & 0xFF) == 0);
            SetFlag(Flags.P, CheckParity((byte)temp));
            SetFlag(Flags.C, temp > 255);

            return 3;
        }
    }
}

