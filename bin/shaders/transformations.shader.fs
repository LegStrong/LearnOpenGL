#version 330 core

in vec3 ourColor;
in vec2 texCoord;

uniform sampler2D mainTex;
uniform sampler2D texture1;

out vec4 FragColor;


void main()
{
    //FragColor = vec4(ourColor, 1.0);
    FragColor = mix(texture(mainTex, texCoord), texture(texture1, texCoord), 0.5);
}