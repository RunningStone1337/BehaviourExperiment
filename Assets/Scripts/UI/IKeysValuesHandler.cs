namespace UI
{
    public interface IKeysValuesHandler
    {
        string SelectedOptionKey { get; set; }
        object SelectedOptionValue { get; }

        void AddOption(string key, object value);

        void RemoveOption(string key);
    }
}