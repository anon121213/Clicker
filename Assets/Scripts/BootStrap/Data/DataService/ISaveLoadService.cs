﻿namespace BootStrap.Data.DataService
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgres LoadProgress();
    }
}