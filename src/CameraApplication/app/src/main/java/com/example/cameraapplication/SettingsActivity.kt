package com.example.cameraapplication

import android.content.Context
import android.content.SharedPreferences
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.text.Editable

import android.text.TextWatcher




class SettingsActivity : AppCompatActivity() {
    private lateinit var sharedPref: SharedPreferences
    private lateinit var ipAddress: String
    private lateinit var port: String

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_settings)
        sharedPref = getSharedPreferences(
            getString(R.string.preference_file_key), Context.MODE_PRIVATE)
        ipAddress = resources.getString(R.string.default_ip_address)
        port = resources.getString(R.string.default_port)
        populateSettings()
        disableSave()

        findViewById<Button>(R.id.save_settings_button).setOnClickListener {
            saveSettings()
        }

        findViewById<EditText>(R.id.ip_address).addTextChangedListener(object : TextWatcher {
            override fun afterTextChanged(s: Editable) {}
            override fun beforeTextChanged(
                s: CharSequence, start: Int,
                count: Int, after: Int
            ) {
            }

            override fun onTextChanged(
                s: CharSequence, start: Int,
                before: Int, count: Int
            ) {
                enableSave()
            }
        })

        findViewById<EditText>(R.id.port).addTextChangedListener(object : TextWatcher {
            override fun afterTextChanged(s: Editable) {}
            override fun beforeTextChanged(
                s: CharSequence, start: Int,
                count: Int, after: Int
            ) {
            }

            override fun onTextChanged(
                s: CharSequence, start: Int,
                before: Int, count: Int
            ) {
                enableSave()
            }
        })
    }

    private fun populateSettings() {
        ipAddress = sharedPref.getString(getString(R.string.ip_address_key), ipAddress).toString()
        port = sharedPref.getString(getString(R.string.port_key), port).toString()
        findViewById<EditText>(R.id.ip_address).setText(ipAddress, TextView.BufferType.EDITABLE)
        findViewById<EditText>(R.id.port).setText(port, TextView.BufferType.EDITABLE)
    }

    private fun saveSettings() {
        ipAddress = findViewById<EditText>(R.id.ip_address).text.toString()
        port = findViewById<EditText>(R.id.port).text.toString()
        with (sharedPref.edit()) {
            putString(getString(R.string.ip_address_key), ipAddress)
            putString(getString(R.string.port_key), port)
            apply()
        }
        disableSave()
    }

    private fun enableSave() {
        findViewById<Button>(R.id.save_settings_button).isEnabled = true;
    }

    private fun disableSave() {
        findViewById<Button>(R.id.save_settings_button).isEnabled = false;
    }
}