using System;

namespace SpecLogLogoReplacer.UI.ViewModel
{
    internal interface ISpecLogTransformer
    {
        void Transform(string pathToSpecLogFile, string pathToLogo);
    }
}