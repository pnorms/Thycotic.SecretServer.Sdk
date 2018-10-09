# Thycotic.SecretServer.Sdk
This library allows you to drop a JSON config file "Thycotic.SecretServer.Sdk.json" in the tss folder (RHEL / Windows both tested) so the *.config files generated by tss init are available to all processes created by the initializing user. This we required for our Ansible Tower HA deployment, no good solution for password managment in a custom dynamic inventory existed. To use simply replace Thycotic.SecretServer.Sdk.dll and Thycotic.SecretServer.Sdk.pdb in the tss directory. In the calling application directory drop the file Thycotic.SecretServer.Sdk.json and configure to point at your init creds.
