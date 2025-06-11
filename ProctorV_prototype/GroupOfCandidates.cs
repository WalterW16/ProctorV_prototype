using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class GroupOfCandidates
    {
        string name; 
        List<User> candidates { set; get; }
        public GroupOfCandidates(string name, List<User> candidats)
        {
            this.name = name;
            this.candidates = candidats;
        }
        public GroupOfCandidates(string name)
        {
            this.name=name;
            this.candidates = new List<User>();
        }
        public void AddCandidate(User candidate)
        {
            this.candidates.Add(candidate);
        }
        public void RemoveCandidate(User candidate)
        {
            this.candidates.Remove(candidate);
        }
        public bool Contains(User candidate)
        {
            return this.candidates.Contains(candidate);
        }
        public int GetCandidatesCount()
        {
            return candidates.Count;
        }
        public string GetName()
        {
            return name;
        }
    }
}
