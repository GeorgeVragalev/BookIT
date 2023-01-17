### Cross-Site Scripting (XSS)

Injecting a malicious script through the input/form field of a webpage with the intension to steal confidential
information such as login credentials or other authentication information, cookies, and session values is called a
cross-site scripting (XSS) attack

As a solution we did use:

* Regular Expression for not allowing other characters that one specific for a normal input.
  Ex: numbers, digits, underscore and minus sign.

* HTML Encoding for that we have the Razor engine which automatically encodes all inputs so that the script part
  provided in any field will never be executed.
* Also we will use URL Encoding, as we use plain text in URL query strings, which can be used to launch XSS attacks. So,
  we should encode the query parameter input in the URL.

### Prevent SQL Injection

* We validate inputs not to allow special characters that are involved in SQL scripts
* We use Entity Framework which is ORM, An ORM (Object-Relational Mapping)  used to interact with relational databases
  using an object-oriented paradigm, which can simplify the development process and make the code more readable and
  maintainable.

### Cross-Site Request Forgery (CSRF)

Cross-Site Request Forgery (CSRF) is a type of attack that occurs when a malicious website, email, or other type of
message causes a user's web browser to perform an unwanted action on a different website for which the user is currently
authenticated.

* We use the ValidateAntiForgeryToken which

### Version Discloser

Whenever the browser sends an HTTP request to the server in response, the browser gets a response header, which contains
the following information. We hided the version information of what we used to develop the application from end users
because if an attacker learns the specific version, then they may try to target an attack on that specific version based
on a previously disclosed vulnerability.

### Enforce SSL (Secure Sockets Layer) and HSTS

HSTS is a web security policy that protects your web application from downgrade protocol attacks and cookie hijacking.
It forces the web server to communicate over an HTTPS connection. It always rejects insecure HTTP connections.

### Improper Authentication and Session Management

We could make mistakes like not removing the authentication cookies after a successful logout. This kind of mistake
allows attackers to steal user credentials such as cookies and session values, and may result in attackers being able to
access the complete application and cause major negative impacts.

The following mistakes can help attackers steal data:

* Insecure connection (without SSL).
* Predictable login credentials.
* Storing plain (unencrypted) credentials.
* Improper application logouts.

  To Avoid These Mistakes we do:
    * Remove cookies after successful logout.
    * Secure cookies and sessions by using SSL.
    * Secure cookies by setting HTTP only.

### File Upload Validation

* First, we check the file upload count. If the upload count is zero, no file is uploaded. If the upload count is greater
than zero, proceed with further validation.
* We check the file extension. This will allow only valid extension files. Sometimes, attackers can still pass malicious
files with allowed extensions. In this case, do further validation.
* Check the file content type and file bytes.
* Only allow uploading the file when the previous three steps are successfully validated.