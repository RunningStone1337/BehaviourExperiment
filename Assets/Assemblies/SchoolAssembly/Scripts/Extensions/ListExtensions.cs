using System.Collections.Generic;
using System.Linq;
using UI;

public static partial class ListExtensions
{
    public static Content FirstOrDefaultMatchContent<Content, ContentHandler>(this List<Content> list, ContentHandler ch)
              where Content : INameHandler
              where ContentHandler : IKeysValuesHandler
              =>
              list.FirstOrDefault(x => x.Name.Equals(ch.SelectedOptionKey));
}