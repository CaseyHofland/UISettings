#if TMP
namespace UISettings
{
    public interface ITMP_DropdownSetting : ISelectableSetting
    {
        void UpdateView(TMPro.TMP_Dropdown tmp_Dropdown);
        void ValueChanged(int value);
    }
}
#endif