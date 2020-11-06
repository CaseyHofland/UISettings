#if TMP
namespace UISettings
{
    public interface ITMP_InputFieldSetting : ISelectableSetting
    {
        void UpdateView(TMPro.TMP_InputField tmp_InputField);
        void ValueChanged(string value);
        void EndEdit(string value);
        void Select(string value);
        void Deselect(string value);
    }
}
#endif