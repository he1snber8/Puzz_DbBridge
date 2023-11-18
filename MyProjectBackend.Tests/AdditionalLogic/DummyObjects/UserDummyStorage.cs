
namespace MyProjectBackend.Tests.AdditionalLogic.DummyObjects;

internal class UserDummy
{
    internal string Username { get; set; }
    internal string Email { get; set; }
    internal string Password { get; set; }

    internal UserDummy(string username,string email,string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}

internal static class UserDummyStorage
{
    private static List<UserDummy> userDummies = new()
    {
        new UserDummy("lhyde0", "hrean0@wordpress.com", "xK1`_q)a*U"),
        new UserDummy("ssherman1", "sberdale1@google.fr", "fI0`ti$\"blea"),
        new UserDummy("fmedforth2", "dmccaghan2@histats.com", "yY1$/vrVWI2s"),
        new UserDummy("acaherny3", "showsam3@storify.com", "yV4/J=Nrz{`e"),
        new UserDummy("bfoyle4", "fgarvagh4@wix.com", "vY0}\"8Bfn((+<"),
        new UserDummy("imccotter5", "asproston5@europa.eu", "vN5\"Z@GyL"),
        new UserDummy("wwithrop6", "bbootell6@jigsy.com", "fE3{6N$A1$lnT.2"),
        new UserDummy("mdanit7", "jkimblin7@indiegogo.com", "tC2}Mt$9NQw"),
        new UserDummy("erainey8", "llepage8@berkeley.edu", "tA5#j#Q7F"),
        new UserDummy("tvallack9", "mfroome9@omniture.com", "jO5+O1bWx9\\/r"),
        new UserDummy("lcrewdsona", "lfeaksa@nih.gov", "wR8.*FJ\\"),
        new UserDummy("gpainterb", "bmckernanb@census.gov", "yX6`~B1!.JV"),
        new UserDummy("lfellc", "ehlavacc@cocolog-nifty.com", "nC1?Un>9*{\"J"),
        new UserDummy("ebolind", "nshired@nifty.com", "kF4&hR@3jYj"),
        new UserDummy("hgeldarte", "wfarryanne@scientificamerican.com", "sK5+wTWi\\owX!6"),
        new UserDummy("cbonnellf", "tbeckhurstf@last.fm", "sN7_@yM.Qs#"),
        new UserDummy("gvellenderg", "chalstong@hc360.com", "aD8>Vl7||<gU"),
        new UserDummy("ddimondh", "ctilbeyh@posterous.com", "tH6%(GRguk!9n"),
        new UserDummy("cboatei", "lfreshwateri@home.pl", "vP8$b*g8%#2yl|\"1"),
        new UserDummy("acuolahanj", "bgregoirej@google.it", "eV6~jG_$"),
        new UserDummy("vraubenheimerk", "fhallamk@live.com", "qG1!AmnGY>Qaw.J"),
        new UserDummy("ngeelyl", "jbrettonerl@answers.com", "mM7_u<15ukc5+"),
        new UserDummy("kgascoynem", "rbraysherm@cocolog-nifty.com", "jC3=nK{_K>4.=hSv"),
        new UserDummy("dchapellen", "cmossonn@netscape.com", "password123")
    };

    public static UserDummy GetRandomDummy() => userDummies[Random.Shared.Next(0, userDummies.Count - 1)];

}
