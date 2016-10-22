using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazegame.Control
{
    public class Parser
    {
        private ArrayList dropWords;
        private ArrayList validCommands;

        public Parser(ArrayList validCommands)
        {
            dropWords = new ArrayList(new String[]{"in", "an", "and", "the", "this", "to"});
            this.validCommands = validCommands;
        }

        public ParsedInput Parse(String rawInput)
        {
            ParsedInput parsedInput = new ParsedInput();
            String lowerCaseInput = rawInput.ToLower();
            ArrayList stringTokens = new ArrayList(lowerCaseInput.Split());
            foreach (String token in stringTokens)
            {
                if (validCommands.Contains(token))
                {
                    parsedInput.setCommand(token);
                }
                else if (!dropWords.Contains(token))
                {
                    parsedInput.getArguments().Add(token);
                }
            }
            return parsedInput;
        }
    }
}
