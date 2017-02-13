uniform vec3 Spacing;
uniform vec3 Size;
uniform sampler2D tex;

void main(void)
{
   float t1 = 0.5;
   float t2 = 0.5;

   if (gl_FragCoord[0] > 200) t1 = 1;
   if (gl_FragCoord[1] > 300) t2 = 1;

   //gl_FragColor = vec4(t1,t2,0, 1.0);
   gl_FragColor = texture(tex, vec2(gl_FragCoord[0] / 255, gl_FragCoord[1] / 255));
}