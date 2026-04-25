# Security policy

## Supported versions

| Version | Supported |
| ------- | --------- |
| 0.1.x   | yes       |

## Reporting a vulnerability

Please do **not** open a public issue for security vulnerabilities. Send a
privately-disclosed report to my Discord at @kyedex with:

- A description of the issue
- Steps to reproduce
- Impact assessment
- Any suggested mitigation

You should receive an acknowledgement within 72 hours. I aim to triage
within 7 days and publish a fix within 30 days for high-severity issues.

## Secrets

- **Never** commit bot tokens, connection strings, or API keys.
- Development uses [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets).
- Production uses environment variables or a managed secrets store.
- `appsettings.*.json` must contain only placeholders.

## Dependencies

Dependencies are pinned in `Directory.Packages.props` under Central Package
Management. The CI workflow runs `dotnet list package --vulnerable` on every push and fails on any known vulnerability.
