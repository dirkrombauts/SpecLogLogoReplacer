using System;

namespace Aim.SpecLogLogoReplacer.UI.ViewModel
{
    internal interface ISpecLogTransformer
    {
        void Transform(string pathToSpecLogFile, string pathToLogo);
    }
}