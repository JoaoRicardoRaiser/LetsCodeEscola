using System;

namespace LestsCodeEscola.Comum
{
    public class EntidadeBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
