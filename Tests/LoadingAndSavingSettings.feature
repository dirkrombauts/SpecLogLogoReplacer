Feature: Loading And Saving Settings

Scenario: Loading Settings
  Given the settings file consists of
    """
    <?xml version="1.0" encoding="utf-8"?>
    <specLogLogoReplacer xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
      <pathToLogo>c:\logo.png</pathToLogo>
      <pathToSpecLogHtmlFile>c:\speclog.html</pathToSpecLogHtmlFile>
    </specLogLogoReplacer>
    """
  When I load the settings
  Then I should have these settings
    | Path to SpecLog Html File | Path to Logo |
    | c:\speclog.html           | c:\logo.png  |

Scenario: Saving Settings
  Given I have these settings
    | Path to SpecLog Html File | Path to Logo |
    | c:\speclog.html           | c:\logo.png  |
  When I save the settings
  Then the settings file consists of
    """
    <?xml version="1.0" encoding="utf-8"?>
    <specLogLogoReplacer xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
      <pathToLogo>c:\logo.png</pathToLogo>
      <pathToSpecLogHtmlFile>c:\speclog.html</pathToSpecLogHtmlFile>
    </specLogLogoReplacer>
    """
