public class VersionControl {
	public int majorVersion { get; protected set; }
	public int minorVersion { get; protected set; }

	public VersionControl(int majorVersion, int minorVersion){
		this.majorVersion = majorVersion;
		this.minorVersion = minorVersion;
	}
}
