namespace KCode.ChangelogTransform.Types
{
    public enum Category
    {
        // Everything uncategorized
        Misc,

        // New features
        Features,
        // Improvements - could be split into GUI, admin, user, hidden/expert, etc
        Improvements,
        // Fixed bugs
        Bugfixes,
        // Fixed issues or potential/theoretical issues
        Hardening,

        // Everything build scripts, build configuration, build job configuration
        BuildInfrastructure,
        // Code formatting, being able to compile on different platforms, code improvements - could be split up further
        Code,
        // Related to translation of Mumble and installer
        Translation,
        // Tests, test programs, src/tests
        Tests,
        ProtocolDocumentation,

        Overlay,
        PositionalAudio,
        Installer,
        Thirdparty,
        Theme,
        Grpc,
        Ice,
        Opus,
        Bonjour,
        Qt5,
        GlobalShortcut,
        BanList,
        OSInfo,
        G15Lcd,
        Filter,
        TextToSpeech,
        Qt4,
        SSL,
    };
}
