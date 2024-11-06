
namespace Levara.Application.Identity.Refresh;

public class RefreshCommandResponse
{
    private const String CodeAnalysisSupressionJustification = "Members of this class conform to the nomenclature specified in RFC 6749.";

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = CodeAnalysisSupressionJustification)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "token", Justification = CodeAnalysisSupressionJustification)]
    public String Access_token { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = CodeAnalysisSupressionJustification)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "in", Justification = CodeAnalysisSupressionJustification)]
    public Int32 Expires_in { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = CodeAnalysisSupressionJustification)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "type", Justification = CodeAnalysisSupressionJustification)]
    public String Token_type { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = CodeAnalysisSupressionJustification)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "type", Justification = CodeAnalysisSupressionJustification)]
    public String Refresh_token { get; set; }
}
