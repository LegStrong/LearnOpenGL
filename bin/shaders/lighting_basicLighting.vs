#version 330

layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 normal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 project;

out vec3 outNormal;
out vec3 outPos;

void main()
{
    gl_Position = project *view * model * vec4(pos, 1.0);
    outPos = vec3(model * vec4(pos, 1.0));
    outNormal = mat3(transpose(inverse(model))) * normal;
}