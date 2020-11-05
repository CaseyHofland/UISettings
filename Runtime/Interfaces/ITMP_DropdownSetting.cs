namespace UISettings
{
    public interface ITMP_DropdownSetting : ISelectableSetting
    {
#if TMP
        void UpdateView(TMPro.TMP_Dropdown tmp_Dropdown);
#endif
        void ValueChanged(int value);
    }
}
