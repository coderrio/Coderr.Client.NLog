NLog adapter for Coderr
=======================

Coderr - Find more errors and solve them faster!

This library is an adapter for Coderr. It picks up all logged exceptions from NLog and 
uploads them to the Coderr Server for further analysis.

You need to install a Coderr Server to be able to analyze and manage the errors.

[Getting started guide](https://coderr.io/documentation/getting-started/)


Configuration
=============

To activate the NLog integration add Coderr to your nlog.config:

```xml
<nlog>
  <extensions>
    <add assembly="Coderr.Client.Nlog"/>
  </extensions>
  <targets>
    <!-- other targets .. -->

    <target name="Coderr" type="Coderr"/>
  </targets>

  <rules>
    <!-- other rules -->

    <logger name="*" minlevel="Debug" writeTo="Coderr" />
  </rules>
</nlog>
```


### Questions
https://discuss.coderr.io/
