# Security Policy

We take the security of **轻净 LiteClean** and its users very seriously. Since this
program operates with system-level permissions to perform optimizations, maintaining a
secure environment is our highest priority.

This document outlines our security policies and explains how to report any discovered
vulnerabilities responsibly.

> 轻净 LiteClean is a modified version of
> [optimizerDuck](https://github.com/itsfatduck/optimizerDuck). Security issues that
> affect the upstream project may also affect this fork — please report them here, and
> we will forward them upstream where appropriate.

## Supported Versions

Currently, we only support the latest release of 轻净 LiteClean for security updates.
We strongly recommend that all users stay up to date with the latest version.

| Version | Supported | Description |
| ------- | --------- | ----------- |
| **Latest Release** | ✅ | Receives all security patches and updates. |
| **Older Versions** | ❌ | No longer supported. Please update immediately. |

## Reporting a Vulnerability

**Please do not open a public issue for security-related matters.**

If you discover a security vulnerability in 轻净 LiteClean, we kindly ask that you
responsibly disclose it to us privately so we can address it before it affects others.

You can report vulnerabilities using one of the following methods:

### Method 1: GitHub Security Advisory (Preferred)

1. Go to the [轻净 LiteClean GitHub Repository](https://github.com/xinpai/LiteClean).
2. Navigate to the **Security** tab.
3. Click on **Advisories** in the sidebar.
4. Click the **Report a vulnerability** button.
5. Provide a detailed description of the issue, including steps to reproduce it.

### Method 2: Email

Send a private report to [164467616@qq.com](mailto:164467616@qq.com).

Please include the version you are running, your Windows build number, and the steps
needed to reproduce the issue.

## What to Expect

Once you report a vulnerability, here is what you can expect from us:

1. **Acknowledgment**: We aim to acknowledge your report within 48 hours.
2. **Investigation**: We will investigate the issue and determine its potential impact. We may reach out to you if we need more information or specific steps to reproduce the vulnerability.
3. **Resolution**: If the vulnerability is confirmed, we will work on a fix as quickly as possible.
4. **Disclosure**: Once a patch is released and users have had a reasonable amount of time to update, we may publish a public security advisory giving you credit for the discovery (if you wish).

## Scope

This security policy covers:

- The core 轻净 LiteClean application (`xinpai/LiteClean`).

It **does not** cover:

- Vulnerabilities in third-party libraries or dependencies (though please report them so we can update our dependencies).
- Issues originating from the Windows operating system itself.

Thank you for helping keep 轻净 LiteClean safe!
